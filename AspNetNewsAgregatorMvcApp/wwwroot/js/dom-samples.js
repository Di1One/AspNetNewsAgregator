function changeBackgroundColorForPreviews() {
    let articlePreviews = document.getElementsByClassName('article-preview');

    console.log('articlePreviews:', articlePreviews);

    for (var i = 0; i < articlePreviews.length; i++) {
        articlePreviews[i].style.backgroundColor = 'rgba(0,148,255, 0.22)';
    }
}





//changeBackgroundColorForPreviews();

