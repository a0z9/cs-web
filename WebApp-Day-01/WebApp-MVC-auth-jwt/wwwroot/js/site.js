
document.getElementById("link_Master").addEventListener("click", async event => {
    event.preventDefault();
   
    await $.ajax(
        {
            url: "/home/master",
            method: "POST",
            headers: { "Authorization": "Bearer " + sessionStorage['token'] },
            complete: (r) => {
                console.log("Status: " + r.status);
                console.log(r);
                if (r.status == 200) document.write(r.responseText);
                else location.href = "/home/status?id=" + r.status;
            }
        }
    );

});


console.log("site script loaded...")
