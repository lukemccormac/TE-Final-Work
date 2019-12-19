/* UPDATE THIS TO YOUR URL /** */
const API_URL = 'https://localhost:44322/api/groceries';

let groceries = [];

document.addEventListener('DOMContentLoaded', () => {
    loadGroceries();

    document.querySelector('ul').addEventListener('click', (event) => {
        if (event.target.nodeName.toLowerCase() === "li") {
            complete(event.target);
        }

        if (event.target.nodeName.toLowerCase() === "i") {
            const li = event.target.parentElement;
            const listItem = getItemById(li.dataset.id);
            li.remove(event.target);
            deleteItem(listItem);
        }
    });

    document.querySelector('ul').addEventListener('dblclick', (event) => {
        if (event.target.nodeName.toLowerCase() === "li") {
            incomplete(event.target);
        } 
    });

    document.querySelector('.addButton').addEventListener('click', ()=> {
        showAdd();
    });

});

function showAdd() {
    if('content' in document.createElement('template')) {
        const list = document.querySelector("ul");
        const tmpl = document.getElementById('shopping-add-item-template').content.cloneNode(true);
        list.appendChild(tmpl);
    } else {
    console.error('Your browser does not support templates');
    }

    const input = document.getElementById('addItem');
    input.addEventListener('keyup', (event) => {
        if (event.key === 'Enter') {
            addItemFromInput();
        }
        if (event.key === 'Escape') {
            removeAddItemForm();
        }
      });
    
    input.focus();

}

function addItemFromInput() {
    const itemName = document.getElementById('addItem').value;
    const itemObj = {
        name: itemName,
        completed: false
    };
    removeAddItemForm();
    const container = document.querySelector("ul");
    addGroceryToList(itemObj, container);

    saveItem(itemObj);

}

function removeAddItemForm() {
   const element = document.querySelector('.addItemForm');
   element.remove(element);
}


function displayGroceries() {
    if('content' in document.createElement('template')) {
        const container = document.querySelector("ul");
        groceries.forEach((item) => {
            addGroceryToList(item, container);
        });

      } else {
        console.error('Your browser does not support templates');
      }
}

function addGroceryToList(item, container) {
    const tmpl = document.getElementById('shopping-list-item-template').content.cloneNode(true);
    tmpl.querySelector("li").dataset.id = item.id;
    tmpl.querySelector("li").insertAdjacentHTML('afterbegin',item.name);
    if( item.completed ) {
      tmpl.querySelector("li").classList.add('completed');
    }
    container.appendChild(tmpl);
}

function complete(item) {
    if (!item.classList.contains('completed')) {
        item.classList.add('completed');
        const listItem = getItemById(item.dataset.id);
        updateItem(listItem, true);
    }
}

function incomplete(item) {
    if (item.classList.contains('completed')) {
        item.classList.remove('completed');
        const listItem = getItemById(item.dataset.id);
        updateItem(listItem, false);
    }
}



function getItemById(id) {
    return groceries.find(obj => obj.id == id);
    
}

/* EXERCISE STARTS HERE */

/**
 * Should load a list of groceries from the API.  
 * On  success if should set the groceries[], and call the displayGroceries() method
 */
function loadGroceries() {
    fetch(API_URL)
        .then((response) => {
            return response.json();
        })
        .then((data) => { 
        groceries = data;
        displayGroceries();
        })
}

/**
 * Should update the provided item to the provided status.
 * 
 * @param {object} item 
 * @param {boolean} completed 
 */
function updateItem(item, completed) {
fetch(API_URL +"/" + item.id, {
    method: "PUT",
    body: JSON.stringify(item),
    headers : {
        "Content-Type": "application/json",
            Accept: "application/json"
    }
})
}

/**
 * Should delete the provided item.
 * 
 * @param {object} item 
 */
function deleteItem(item) {
    fetch(API_URL +"/" + item.id, {
        method: "DELETE"
      });
}


/**
 * Should create a new item
 * @param {object} item 
 */
function saveItem(item) {

  fetch(API_URL, {
    method: "POST",
    body: JSON.stringify(item),
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json"
    }
  })
    .then(response => {
      return response.json();
    })
    .then(json => {
      console.log(json);
    });
  
}
