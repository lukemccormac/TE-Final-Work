document.addEventListener("DOMContentLoaded", () => {

    // Teletype sound file from https://www.freesfx.co.uk/sfx/teletype 
    // 15830_1460490194.mp3 editied with Ocenaudio editor
    // Converted to .ogg file

    // .ico file from http://www.iconarchive.com/search?q=news

    stories = []
    story = {}
    apiKey = "";

    const news = document.getElementById("news");
    const collectApi = document.getElementById("collectApi");
    const saveBtn = document.getElementById("saveBtn");

    //is there a key for newsAPI.org?
    if (localStorage.getItem("storedApiKey")) {
        apiKey = localStorage.getItem("storedApiKey");
        apiBtn.innerText = "Change API key"
    }
    else {
        apiBtn.innerText = "Enter API key"
    }

    let url = [];
    let urlNext = 0;
    loadUrls();

    const lineLimit = 120; // characters per line
    const characterSpeed = 100 //100 ms
    const refresh = 10000 //10 seconds

    var t1 = setInterval(pushBuffer, refresh);
    var t2 = setInterval(popBuffer, characterSpeed);

    const hideShow = document.getElementById("hideControl");
    const player = document.getElementById("player");

    const help = document.getElementById("help");

    // startup
    pushBuffer();


    help.addEventListener('click', () => {
        if (helpMessage.classList.contains("d-none")) {
            helpMessage.classList.remove("d-none");
        } else {
            helpMessage.classList.add("d-none");
        }
    })

    hideControl.addEventListener('click', () => {
        if (hideShow.checked == true) {
            controls.classList.add("d-none");
            controls.classList.remove("d-inline-block");
        } else {
            controls.classList.add("d-inline-block");
            controls.classList.remove("d-none");
        }
    })

    // test key is  8bee824932ee4380af56611454a2a59f

    apiBtn.addEventListener("click", function () {
        apiKey = prompt("Enter API Key:");
        if (apiKey) {
            localStorage.setItem("storedApiKey", apiKey);
            loadUrls();
            pushBuffer();
        }
    });

    function loadUrls() {
        url[0] = 'https://newsapi.org/v2/top-headlines?country=gb&apiKey=' + apiKey;
        url[1] = 'https://newsapi.org/v2/top-headlines?country=us&apiKey=' + apiKey;
        url[2] = 'https://newsapi.org/v2/everything?q=ohio&apiKey=' + apiKey;
        urlNext = 0;
    }

    function pushBuffer() {
        if (stories.length < 10) {
            fetch(url[urlNext])
                .then((resp) => {
                    if (!resp.ok) {
                        console.log(resp)
                        throw resp.statusText
                    }
                    return resp.json()
                })
                .then(function (data) {

                    urlNext++;
                    if (urlNext >= url.length) {
                        urlNext = 0
                    }

                    let articles = [];
                    articles = data.articles;
                    articles.forEach(article => {
                        stories.push(article);
                    });
                })
                .catch((error) => {
                    console.log(error)
                });
        }
    }

    function popBuffer() {
        if (stories.length > 0) {
            if (story == undefined ||
                story.title == undefined ||
                story.title.length == 0) {

                story = stories.shift()
                story.title += "  --  ";
            }

            let oneCharacter = story.title.substr(0, 1);
            story.title = story.title.substr(1);
            let current = news.innerHTML

            //add charatrs at the end of the display
            current += oneCharacter;

            // take character off the beginning of the display
            if (current.length > lineLimit) {
                current = current.substr(current.length - lineLimit);
            }
            news.innerHTML = current
        }
    }
})

