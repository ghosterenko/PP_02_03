document.querySelector("#calculateBtn").addEventListener("click", () => {
    calc()
})

function calc() {
    const area = document.querySelector("#area").value
    const type = document.querySelector("#type").value
    const city = document.querySelector("#city").value
    const promo = document.querySelector("#promo").value

    if(!area || !type || !city) {
        alert("Заполните пустые поля")
        return
    }

    const url = "http://localhost:5000/api/calculate?area=" + area + "&type=" + type + "&city=" + city + "&promo=" + promo;

    fetch(url)
        .then(res => res.json())
        .then(data => {
            document.querySelector("#basePrice").textContent = data.basePrice + " Руб."
            document.querySelector("#discountPercent").textContent = data.discountPercent + " %"
            document.querySelector("#delivery").textContent = data.delivery + " Руб."
            document.querySelector("#bonus").textContent = data.bonusPoints + " Баллов"
            document.querySelector("#total").textContent = data.total + " Руб."
        })
        .catch(() => {
            alert("Ошибка")
        })
}

