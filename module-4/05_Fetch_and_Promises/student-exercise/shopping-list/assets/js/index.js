let list = [];

function loadShoppingList() {
  console.log("Load Shopping List...");

  fetch('assets/data/shopping-list.json')
  .then((response) => {
    return response.json();
  })
  .then((lists) => {
    if('content' in document.createElement('template')) {
      let items = document.querySelectorAll('ul li');      
      list = document.querySelector("ul");
      items.forEach((item) => {
        list.removeChild(item);
      })
      lists.forEach((item) => {
        const tmpl = document.getElementById('shopping-list-item-template').content.cloneNode(true);
        tmpl.querySelector("li").insertAdjacentHTML('afterbegin', item.name);
        if( item.completed ) {
          const circleCheck = tmpl.querySelector('.fa-check-circle');
          circleCheck.className += " completed";
        }
        list.appendChild(tmpl);
      });
    } else {
      console.error('Your browser does not support templates');
    }
  })
  .catch((err) => {console.error(err)});
}
document.addEventListener("DOMContentLoaded", (event) => {
const button = document.querySelector(".loadingButton");
  button.addEventListener("click",function() {
  loadShoppingList();
  button.disabled = true;
  });
})
