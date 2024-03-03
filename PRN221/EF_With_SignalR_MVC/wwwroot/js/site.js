$(() => {
    LoadProdData();

    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();

    connection.on('LoadProducts', function () {
        LoadProdData();
    })

    LoadProdData();

    function LoadProdData() {
        var tr = '';

        $.ajax({
            url: '/Products/GetProducts',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `<tr>
                         <td> ${v.prodId} </td>
                         <td> ${v.prodName} </td>
                       <td> ${v.category}</td >
                        <td> ${v.unitPrice}</td>
                        <td> ${v.stockQty} </td>
                        <td>
                            <a href='../Students/Edit?id=${v.ProdId}'>Edit</a> |
                            <a href='../Students/Details?id=${v.ProdId}'>Details</a> |
                            <a href='../Students/Delete?id=${v.ProdId}'>Delete</a>
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