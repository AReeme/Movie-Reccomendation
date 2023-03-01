const form = document.getElementById("Movie-Quiz");
const checkboxes = document.querySelectorAll('input[type="checkbox"]');
const radioButtons = document.querySelectorAll("input[type='radio']");
const questions = form.querySelectorAll(".question");
let currentQuestionIndex = 0;

questions[currentQuestionIndex].classList.add("active");

const nextButton = document.querySelector(".next-button");
const finishButton = document.querySelector(".finish-quiz");

nextButton.addEventListener("click", (event) => {
    event.preventDefault(); // prevent the default form submission behavior
    questions[currentQuestionIndex].classList.remove("active");
    currentQuestionIndex += 1;
    if (currentQuestionIndex >= questions.length - 1) {
        nextButton.style.display = "none";
        finishButton.style.display = "block";
    }
    questions[currentQuestionIndex].classList.add("active");
    if (currentQuestionIndex === questions.length - 1) {
        nextButton.style.display = "none";
        finishButton.style.display = "block";
    }
    return false; // prevent the form from being submitted
});

// Check if the selected answer in the first question is also selected in the second question
form.addEventListener("change", (event) => {
    if (event.target.type === "checkbox") {
        checkboxes.forEach(checkbox => {
            if (checkbox.value === event.target.value && checkbox !== event.target) {
                checkbox.disabled = event.target.checked;
            }
        });
    }
});