


const showAddForm = function (element) {
    const table = document.createElement('table');
    table.className = "students";

    const columns = [
        { "id": "id", "name": "Id" },
        { "id": "name", "name": "Имя", "type": "text" },
        { "id": "email", "name": "Эл. почта", "type": "text" },
        { "id": "isReady", "name": "isReady", "type": "bool" }
    ];

    let records = '<tr>';
    columns.forEach(col => records += `<th class=${col.id}>${col.name}</th>`)
    records += '</tr><tr>';

    records += '<td class="id"> </td>';
    records += '<td class="name"><input name="name" /> </td>';
    records += '<td class="email"><input name="email"/> </td>';
    records += '<td class="isReady"><input name="isReady" type="checkbox"/> </td>';

    records += '</tr>';

    table.innerHTML = records;
    element.innerHTML = '';
    element.appendChild(table);

}


const updateStudents = function (element, url) {
   
    const table = document.createElement('table');
    table.className = "students";

    const columns = [
        { "id": "id", "name": "Id" },
        { "id": "name", "name": "Имя" },
        { "id": "email", "name": "Эл. почта" },
        { "id": "isReady", "name": "isReady" }
    ];

    let records = '<tr>';
    columns.forEach(col => records += `<th class=${col.id}>${col.name}</th>`)
    records += '</tr>';

    //students.innerHTML = "students list";

    //const url = location.origin + "/students"; //"https://localhost:7203/students";


    fetch(url,
        { method: "GET" }).
        then((resp) => resp.json()).
        then((data) => {
            //console.log(data);

            data.forEach(student => {
                console.log(student);
                records += '<tr>';
                columns.forEach(col => records += `<td class=${col.id}>${student[col.id]}</td>`);
                records += '</tr>';
            });
            //console.log('fetch:', records);
            table.innerHTML = records;
            element.innerHTML = '';
            element.appendChild(table);
        });

    //console.log("main:", records);
};