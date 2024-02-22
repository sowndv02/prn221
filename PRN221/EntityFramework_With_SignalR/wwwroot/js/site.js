$(() => {
    LoadProdData();

    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();

    connection.on('LoadStudents', function () {
        LoadProdData();
    })

    LoadProdData();

    function LoadProdData() {
        var tr = '';

        $.ajax({
            url: '/Students/OnGetStudents',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `<tr>
                         <td> ${v.Id} </td>
                         <td> ${v.Name} </td>
                       <td> ${v.Gender}</td >
                        <td> ${v.DepartId}</td>
                        <td> ${v.Dob} </td>
                        <td> ${v.Gpa} </td>
                        <td>
                            <a href='../Students/Edit?id=${v.Id}'>Edit</a> |
                            <a href='../Students/Details?id=${v.Id}'>Details</a> |
                            <a href='../Students/Delete?id=${v.Id}'>Delete</a>
                        </td>
                        </tr>`
                })
                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }
})