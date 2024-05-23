const parentImage = document.querySelector(".slider-image-parent");
const childImages = document.querySelectorAll(".slider-image-child");
const slideName = document.querySelector(".room-name");
const filterForm = document.querySelector(".filter");
const checkInInput = document.getElementById("checkIn");
const checkOutInput = document.getElementById("checkOut");
const checkInError = document.getElementById("reqIn");
const checkInValid = document.getElementById("validIn");
const checkOutError = document.getElementById("reqOut");
const checkOutValid = document.getElementById("validOut");
const nameInput = document.getElementById("nameInput");
const emailInput = document.getElementById("emailInput");
const messageInput = document.getElementById("messageInput");
const nameRegister = document.getElementById("nameRegister");
const emailRegister = document.getElementById("emailRegister");
const messageRegister = document.getElementById("messageRegister");
const emailValid = document.getElementById("emailValid");
const closeBtn = document.querySelector(".close-btn")
const overlay = document.querySelector(".overlay")


function changeSlider(img) {
  parentImage.src = img;
  childImages.forEach((image, i) => {
    if (image.src.includes(img)) {
      image.classList.add("active");
      switch (i) {
        case 0:
          slideName.innerHTML = "Living Room";
          break;

        case 1:
          slideName.innerHTML = "Dining Room";
          break;
        case 2:
          slideName.innerHTML = "Bedroom";
          break;
        case 3:
          slideName.innerHTML = "Living Room II ";
          break;
      }
    } else {
      image.classList.remove("active");
    }
  });
}
let isValid = true;
checkInInput.addEventListener("keyup",()=>{
  
  checkInError.className = "d-none";
  
})
checkOutInput.addEventListener("keyup",()=>{
  checkOutError.className = "d-none";
  
})
filterForm.addEventListener("submit", (e) => {
  let datePattern = /^\d{2}\d{2}\d{4}$/;

  if (checkInInput.value.trim() == "") {
    checkInError.className = "required";
    checkInValid.className = "d-none";

  } else {
    if (datePattern.test(checkInInput.value)) {
      checkInValid.className = "d-none";
    } else {
      checkInValid.className = "required";
    }
    checkInError.className = "d-none";
  }
  if (checkOutInput.value.trim() == "") {
    checkOutError.className = "required";
    checkOutValid.className = "d-none";
  } else {
    if (datePattern.test(checkOutInput.value)) {
      checkOutValid.className = "d-none";
    } else {
      checkOutValid.className = "required";
    }
    checkOutError.className = "d-none";
  }

  if (!checkInInput.value.trim() == "" && !checkOutInput.value.trim() == "") {
    if (
      datePattern.test(checkInInput.value) &&
      datePattern.test(checkOutInput.value)
    ) {
      let checkObj = {
        checkIn: checkInInput.value,
        checkOut: checkOutInput.value,
      };
      fetch("https://6622d9c13e17a3ac846e1a5a.mockapi.io/test", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(checkObj),
      });

      checkInInput.value = "";
      checkOutInput.value = "";
    }
  }

  e.preventDefault();
});

(function () {
  emailjs.init("5v5TsNF9LD7u5G8mr");
})();

function sendMail(e) {
  e.preventDefault();

  const emailForm = document.querySelector(".email-form");
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

  if (
    !emailInput.value.trim() == "" &&
    !nameInput.value.trim() == "" &&
    !messageInput.value.trim() == ""
  ) {
    if (!emailRegex.test(emailInput.value)) {
      emailValid.classList = "required";
    } else {
      emailjs
        .sendForm(
          "service_jkzzetq",
          "template_wu648in",
          emailForm,
          "5v5TsNF9LD7u5G8mr"
        )
        .then(
          (response) => {
            alert("Mail göndərildi");
          },
          (error) => {
            console.log("FAILED...", error);
          }
        );
      emailValid.classList = "d-none";
      emailInput.value = "";
      nameInput.value = "";
      messageInput.value = "";

      return false;
    }
  }
  // email
  if (emailInput.value.trim() == "") {
    emailRegister.className = "required";
  } else {
    if (!emailRegex.test(emailInput.value)) {
      emailValid.classList = "required";
    }
    emailRegister.className = "d-none";
  }
  // name
  if (nameInput.value.trim() == "") {
    nameRegister.className = "required";
  } else {
    nameRegister.className = "d-none";
  }
  // message
  if (messageInput.value.trim() == "") {
    messageRegister.className = "required";
  } else {
    messageRegister.className = "d-none";
  }
}
emailInput.addEventListener("keyup",()=>{
  emailRegister.className = "d-none";

})
nameInput.addEventListener("keyup",()=>{
  nameRegister.className = "d-none";

})
messageInput.addEventListener("keyup",()=>{
  messageRegister.className = "d-none";

})

window.addEventListener('resize', updateScreenWidth);
const mainElem = document.querySelector(".main-elem")
function updateScreenWidth(){

  let screenWidth = window.innerWidth;
  if(screenWidth <= 993){
    mainElem.classList.remove("container")
  }else{
    mainElem.classList.add("container")
    overlay.classList.remove("active");

  }
}


// toggle menu
const menuBar = document.querySelector(".toggle")
const asidePanel = document.querySelector(".aside-panel")
menuBar.addEventListener("click",()=>{
   asidePanel.classList.toggle("d-block")
   overlay.classList.toggle("active");
})

closeBtn.addEventListener("click",()=>{
  asidePanel.classList.remove("d-block")
  overlay.classList.remove("active");

})
overlay.addEventListener("click",()=>{
  asidePanel.classList.remove("d-block")
  overlay.classList.remove("active");
})

