var homeController = {
    init: function () {
        homeController.registerEvent();
        homeController.loadData();
    },
    registerEvent: function () {

    },
    loadData: function () {
        $.ajax({
            url: 'Admin/QLSanPham/GetList',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                var data = response.data;
                var html = '';
                var template = $('#data-template').html;
                $.each(data, function (i, item) {
                    html += Mustache.render(template, {
                        maSP: item.maSP,
                        tenSP: item.tenSP,
                        giaBan: item.giaBan,
                        hinhAnh: item.hinhAnh,
                    });

                });
                $('#tb').html(html);
            }
        })
    }
}homeController.init();