// function sayHello(){
//     console.log("Hola mundo");
// }

// alert("Hola mundo")

///////////////////////////////////////////
// var saldo=0;
// function agregar(parametro){
//     saldo+= parametro;
//     console.log(saldo);
// }

// document.addEventListener('click', function(){
//     agregar(2);
// })

/////////////////////////////////////////////////////////
// var scope={
//     get(){
//         return provisional; 
//     },
//     set valor(parametro){
//         this.provisional=parametro;
//         document.querySelector("#result").innerHTML=this.provisional;
//     },
//     provisional:""
// };

// document.querySelector("#questionName").addEventListener('input',function(event){
//     scope.valor=event.target.value;
// })   


/////////////////////////////////////////
// const object={
//     consola: function consola(){
//         console.log(this);
//     },
//     name="Mi objeto persona"
// }

// setTimeout(objeto.consola,1000)

var questioncount=0;

function rename(){
    newrow()
    var newtitle = document.getElementById("questionName").value
    var target="questionName"+questioncount;
    document.getElementById(target).innerHTML=newtitle
    questioncount+=1; 
}

function newrow() {
    document.getElementById("questionList").innerHTML += "<section id='savedQuestion"+questioncount+
    "'><h2 id='questionName"+questioncount+
    "'>Question 1</h2><li><form action=''><input type='text' name=' id='><input type='button' value='add new'></form></li>"+
    "<li><input type='radio' name='' id=''>Texto random</li>"+
    "<li><button type='submit' name='Eliminar' value='"+questioncount+
    "' onclick='deletequestion(this.value)'>Eliminar</button></li></section>"
}

function deletequestion(number){
    var question = "savedQuestion"+number;
    var todelete = document.getElementById(question)
    todelete.parentNode.removeChild(todelete);
}

document.getElementById("titleForm").addEventListener("submit",function(){
    rename();
})

document.getElementById("questionList").addEventListener("submit",function(number){
    deletequestion(number);
})








