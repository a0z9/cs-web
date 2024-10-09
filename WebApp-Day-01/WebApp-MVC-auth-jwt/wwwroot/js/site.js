
//document.getElementById("link_Master").addEventListener("click", async event => {
//    event.preventDefault();
   
//    await $.ajax(
//        {
//            url: "/home/master",
//            method: "POST",
//            headers: { "Authorization": "Bearer " + sessionStorage['token'] },
//            complete: (r) => {
//                console.log("Status: " + r.status);
//                console.log(r);
//                if (r.status == 200) {
//                    document.body.innerHTML = '';
//                    document.write(r.responseText);
//                }
//                else location.href = "/home/status?id=" + r.status;
//            }
//        }
//    );

//});


document.querySelectorAll('.grades').forEach((element) =>
{
    element.onclick = async function (event){

        event.preventDefault();
        //console.log(event);
        //console.log(event.originalTarget.href);
        let url_segments = event.originalTarget.href.split("/");
        const action = url_segments.pop();
        const controller = url_segments.pop();
        const url = `/${controller}/${action}`;
        console.log(url);

        await $.ajax(
            {
                url: url,
                method: "POST",
                headers: { "Authorization": "Bearer " + sessionStorage['token'] },
                complete: (r) => {
                    console.log("Status: " + r.status);
                    console.log(r);
                    if (r.status == 200) {
                        document.body.innerHTML = '';
                        document.write(r.responseText);
                    }
                    else location.href = "/home/status?id=" + r.status;
                }
            });
       

    }
}


);


console.log("site script loaded...")
