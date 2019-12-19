 //console.log("hello");
 let John = {name: "John", position: "instructor", 
 lengthOfService: 3}
 let Brian = {name: "Brian", position: "instructor", 
 lengthOfService: 2}

 let instructors =[John, Brian]
 //console.log(instructors);

// console.log(instructors[1].name);
// console.log(instructors[1]["name"]);


 let instObject = new Object;

 instObject.senior = John; 
 instObject.junior = Brian;

 //console.log(instObject.junior);
// console.log(instObject.junior.name);

 console.log(instObject["junior"]["name"]);//same as line 20, just different way 