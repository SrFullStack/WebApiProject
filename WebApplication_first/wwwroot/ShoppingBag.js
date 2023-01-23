window.addEventListener("load", GetBasket());

const cart = [];

function GetBasket() {
   

    var cart = sessionStorage.getItem('basket');
    if (cart) {
        cart = JSON.parse(cart);
    } 

    DrowCart(cart)
}

function DrowCart(cart) {

    for (var i = 0; i <= cart.length; i++) {
        var basket = cart[i];
        DrowCarts(basket, cart);
    }
}
function DrowCarts(basket,cart) {
    //
    var temp = document.getElementById("temp-row");
    var clon = temp.content.cloneNode(true);
 clon.querySelector(".price").innerText = basket.price;
    clon.querySelector(".itemName").innerText = basket.name;
    totalsum = sessionStorage.getItem('totalsum');
    document.getElementById("totalAmount").innerHTML = totalsum;
    document.getElementById("itemCount").innerHTML = cart.length;
    clon.querySelector(".image").style.backgroundImage = `url(./image/${basket.imageUrl})`;
    clon.querySelector(".showText").addEventListener("click", () => RemoveItem(basket))
   document.body.appendChild(clon);
}
async function placeOrder() {
    let totalprice = (JSON.parse(document.getElementById("totalAmount").innerText));
    var user = sessionStorage.getItem('current')
    if (user) {
        user=JSON.parse(user)
    }
    userId = user.userid;
    var cart = sessionStorage.getItem('basket');
    if (cart) {
        cart = JSON.parse(cart);
    }
    const order_item = [];
    date = new Date();
    for (var i = 0; i < cart.length; i++) {
        carid = cart[i].id;
        newItem = {
            "carid": carid,
            "quantity": 1
        };
        order_item.push(newItem);
    }

        datils = { "date": date, "sum": totalprice, "userId": userId, "orderItems": order_item };


        const res = await fetch("https://localhost:44354/api/Orders", {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'POST',
            body: JSON.stringify(datils)
        })
   

    }

const basket = [];
function RemoveItem(basket) {
    var cart = sessionStorage.getItem('basket');
    if (cart) {
        cart = JSON.parse(cart);
    }
    for (var i = 0; i < cart.length; i++) {
        if (cart[i].id == basket.id) {
            cart.splice(cart[i], 1)
            basket = cart;
            sessionStorage.setItem('basket', JSON.stringify(basket));
            Remove();
            totalsum = sessionStorage.getItem('totalsum');
            totalsum = (JSON.parse(totalsum));
            totalsum = totalsum - cart[i].price;
            sessionStorage.setItem('totalsum', totalsum)
            DrowCart(basket);
        }


    }




}
function Remove() {
     var arrItem = document.getElementsByClassName("item-row");
    for (var i = arrItem.length-1; i >= 0; i--) {
        document.body.removeChild(arrItem[i]);
    }
}
