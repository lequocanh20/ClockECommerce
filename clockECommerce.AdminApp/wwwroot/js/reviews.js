var ReviewController = function () {
    this.initialize = function () {
        registerEvent();
        $('.btn-review').click(function () {
            window.location.href = $(this).data('url');
        });
    }

    function registerEvent() {
        $('body').on('click', '.btn-browser-status', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            browserReview(id);
        });
    }

    function browserReview(id) {
        $.ajax({
            type: 'POST',
            url: '/Review/BrowserReview',
            data: {
                reviewId: id
            },
            success: function (res) {
                localStorage.setItem("browserReview", true);
                location.reload();
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    $(document).ready(function () {
        // This function will run on every page reload, but the alert will only 
        // happen on if the buttonClicked variable in localStorage == true
        if (localStorage.getItem("browserReview")) {
            localStorage.removeItem("browserReview");
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Cập nhật trạng thái bình luận thành công',
                showConfirmButton: false,
                timer: 1500,
            })
        } 
    });
}


