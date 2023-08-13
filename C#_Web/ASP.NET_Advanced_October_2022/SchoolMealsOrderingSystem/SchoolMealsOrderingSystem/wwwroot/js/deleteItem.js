function myConfirm(e) {
    e.preventDefault();
    Swal.fire({
        title: 'Сигурни ли сте?',
        text: "Това е необратим процес!",
        icon: 'warning',
        showCancelButton: true,
        cancelButtonText: 'Отмени',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Да, премахни!'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                'Премахнато!'
            ).then((resultDeleted) => {
                e.target.parentElement.parentElement.submit();
            })
        }
    })
}
