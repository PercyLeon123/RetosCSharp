
function ValidaMessage(_title, _text, _icon) {
    return new Promise((resolve) => {

        Swal.fire({
            title: _title,
            text: _text,
            icon: _icon,
            showCancelButton: false,
            showConfirmButton: true,
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false,
            stopKeydownPropagation: false,

        }).then((result) => {
            if (result.isConfirmed) {
                resolve(true);
            }
        })
    })
}