
document.getElementById("master").addEventListener("click", async event => {

    await $.ajax(
        {
            url: "/home/master",
            method: "POST",
            headers: { "Authorization": "Bearer " + sessionStorage['token'] },
            complete: (r) => {
                console.log("Status: " + r.status);
                console.log(r);
            }
        }
    );


});


console.log("site script loaded...")
