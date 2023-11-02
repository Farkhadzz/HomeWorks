// // Task 1

// var userName = prompt("Введите Ваше Имя :");
// alert("Привет, " + userName + "!");

// // Task 2

// var currentDate = new Date().getFullYear();
// var userDate = prompt("Введите Ваш Год Рождения");
// var userAge = currentDate - userDate;

// alert("Вам " + userAge + "Лет");

// // Task 3

// var sideLength = prompt("Введите длину стороны квадрата:");

// if (sideLength !== null && sideLength !== "") {
//   sideLength = parseFloat(sideLength);
  
//   if (!isNaN(sideLength) && sideLength > 0) {
//     var perimeter = 4 * sideLength;
    
//     alert("Периметр квадрата равен " + perimeter);
//   } else {
//     alert("Пожалуйста, введите корректное положительное число.");
//   }
// } else {
//   alert("Вы не ввели длину стороны квадрата.");
// }

// // Task 4

// var radius = prompt("Введите радиус окружности:");

// if (radius !== null && radius !== "") {
//   radius = parseFloat(radius);
  
//   if (!isNaN(radius) && radius > 0) {
//     var area = Math.PI * Math.pow(radius, 2);
//     area = area.toFixed(2);
    
//     alert("Площадь окружности равна " + area);
//   } else {
//     alert("Пожалуйста, введите корректное положительное число для радиуса.");
//   }
// } else {
//   alert("Вы не ввели радиус окружности.");
// }

// // Task 5

// var distance = prompt("Введите расстояние между городами (в километрах):");

// var time = prompt("Введите, за сколько часов вы хотите добраться:");

// if (distance !== null && distance !== "" && time !== null && time !== "") {
//   distance = parseFloat(distance);
//   time = parseFloat(time);
  
//   if (!isNaN(distance) && !isNaN(time) && time > 0) {
//     var speed = distance / time;
    
//     alert("Для того чтобы успеть вовремя, вам необходимо двигаться со скоростью " + speed.toFixed(2) + " км/ч.");
//   } else {
//     alert("Пожалуйста, введите корректные значения для расстояния и времени.");
//   }
// } else {
//   alert("Вы не ввели расстояние и/или время.");
// }

// // Task 6

// const euro = 0.94;
// var dollar = prompt("Введите Сумму В Долларах : ");

// var res = dollar * euro;

// alert("Cумма В Euro : " + res.toFixed(2));

// // Task 7
// var flashSize = prompt("Введите объем флешки : ");
// var mbSize = 820;
// var filesCount = Math.floor((flashSize * 1024) / mbSize);

// alert("На флешку поместится : " + filesCount);

// // Task 8
// var walletAmount = prompt("Введите сумму денег : ");
// var chocolatePrice = prompt("Введите цену одной шоколадки:");
// var chocolatesCount = Math.floor(walletAmount / chocolatePrice);
// var change = walletAmount % chocolatePrice;

// alert("Вы можете купить " + chocolatesCount + ". У вас останется " + change.toFixed(2));

// // // Task 9
// var number = prompt("Введите трехзначное число : ");
// var reversedNumber = (number % 10) * 100 + Math.floor((number % 100) / 10) * 10 + Math.floor(number / 100);

// alert(reversedNumber);

// // Task 10

// var userInput = prompt("Введите целое число:");

// if (userInput !== null && userInput !== "") {
//   userInput = parseInt(userInput);

//   var isEven = userInput % 2 === 0;

//   var result = isEven ? "Число четное." : "Число нечетное.";
//   alert(result);
// } else {
//   alert("Вы не ввели целое число.");
// }