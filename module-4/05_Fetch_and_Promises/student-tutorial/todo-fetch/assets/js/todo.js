[
    {"task" : "Wake up", "completed":true}, 
    {"task" : "Morning Movement", "completed":true}, 
    {"task" : "Coffee", "completed":true}, 
    {"task" : "Journal", "completed":true}, 
    {"task" : "Shower & Get Dressed", "completed":false}, 
    {"task" : "Drive to work", "completed":false}, 
    {"task" : "Give Presentation", "completed":false}, 
    {"task" : "Drive Home", "completed":false}, 
    {"task" : "Eat Dinner", "completed":false}, 
    {"task" : "Go to Sleep", "completed":false}
  ]
  // read the tasks from data.json
fetch('data.json')
.then((response) => {
  // get the JSON from the response
  return response.json();
})
.then((todos) => {
  // when the JSON data is returned log the result
  console.log(todos);
})
.catch((err) => {console.error(err)});

