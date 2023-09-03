function myConfirm(e) {
    e.preventDefault();
    Swal.fire({
        title: 'Are You Sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                'Deleted!'
            ).then((resultDeleted) => {
                e.target.parentElement.parentElement.submit();
            })
        }
    })
}
