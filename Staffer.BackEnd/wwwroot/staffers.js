async function getAllUsers() {
    let response = await fetch("/staffers", {
        method: "GET",
        headers: {
            "Accept": "application/json"
        },
    });

    if (response.ok) {
        let staffers = await response.json();
        let table_body = document.getElementById("table-body")
        staffers.forEach(staffer => row(table_body, staffer));
        return staffers;
    } else {
        console.log("Ошибка HTTP: " + response.status);
    }
}

function row(table_body, staffer) {
    table_body.innerHTML += `
    <tr>
        <th scope="row">${staffer.id}</th>
        <td>${staffer.lastName}</td>
        <td>${staffer.firstName}</td>
        <td>${staffer.dateOfBirth}</td>
        <td>${staffer.department}</td>
        <td>${staffer.position}</td>
        <td></td>
    </tr>`;
}

let staffers = getAllUsers();
