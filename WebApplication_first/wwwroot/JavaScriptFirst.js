

async function login() {


    const nameuser = document.getElementById("user").value;

    sessionStorage.setItem('name', nameuser);
    f = sessionStorage.getItem("name")
    
    alert(f)
  
    const password = document.getElementById("password").value;
    const firstname = document.getElementById("firstname").value;
    const lastname = document.getElementById("lastname").value;
    const email = document.getElementById("email").value;
   
    datails = { email: email, nameuser: nameuser, password: password, firstname: firstname, lastname: lastname };

    const res = await fetch("https://localhost:44354/api/user", {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'POST',
        body: JSON.stringify(datails)
    })

}


async function get() {
   
    const password = document.getElementById("system").value;
    const nameuser = document.getElementById("nameuse").value;

    const ress = await fetch(`https://localhost:44354/api/user/?nameuser=${nameuser}&password=${password}`)
    const res1 = await ress.json();



    if (res1.nameuser==nameuser) {
        sessionStorage.setItem('current', JSON.stringify(res1));
        window.location.href = "Login.html"
    }
  

}
async function update() {
    const nameuser1 = sessionStorage.getItem("current");
    current = JSON.parse(nameuser1)
    const nameuser = current.nameuser;
  
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const firstname = document.getElementById("firstname").value;
    const lastname = document.getElementById("lastname").value;
    datails = { userid: current.userid, nameuser: nameuser, email: email, password: password, firstname: firstname, lastname: lastname };
   
    const res = await fetch(`https://localhost:44354/api/user/${current.userid}`, {
        headers: { "Content-Type": "application/json" },
        method: 'PUT',
        body: JSON.stringify(datails)
    });


    
}
async function checkPassword() {
    const code = document.getElementById("password").value;
    const res = await fetch("https://localhost:44354/api/Password", {
        headers: { "content-type": "application/json" },
        method: 'POST',
        body: JSON.stringify(code)
    });
    if (res.ok) {

        let res2 = await res.json()
        document.getElementById("pass").value = res2;
        await alert(res2);
    }
}
ok = () => {
    let userobject = sessionStorage.getItem('current')
    const tmp = JSON.parse(userobject);
    const real = tmp.firstname;
    document.getElementById("helloUser").innerHTML = `hello ${real}!!!!!!!!!`;
   document.getElementById("details").style.display = "block"

}
usernew = () => {
    document.getElementById("details").style.display = "block"
}

async function login1() {
    const res = await fetch("https://localhost:44354/api/user")


    if (!res.ok) {
        throw Error ("you cant conect ")
    }
    if (res.status == 204) {
        alert( "status ")
    }
    if (res.ok) {
        const reg = await res.json()
     /*   alert(reg)*/
    }
  

    

   
}