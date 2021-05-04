function uploadPhoto(e) {
    document.getElementById('image').classList.remove('tr__hidden');
    document.getElementById('video').classList.add('tr__hidden');
    var event = new CustomEvent('uploadPhoto', {
        bubbles: true,
        cancelable: true,
        detail: {
            inputElement: document.getElementById('photo-upload'),
            submitPath: '/custom/show/uploader.php',
            postFileName: 'afile',
            trackerCanvas: document.getElementById('image'),
            success: addUserPhoto,
            error: function (data) {

            }
        }
    });
