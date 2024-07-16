let sections = document.querySelectorAll('sub-container');

    window.onscroll = () => {
    sections.forEach(sec => {
        let top = window.scrollY;
        let offset = sec.offsetTop;
        let height = sec.offsetHeight;

        if (top >= offset && top < offset + height) {
            sec.classList.add('show-animate');
        }
        //if want to use repeating animation on scroll use this
        else {
            sec.classList.remove('show-animate');
        }
    })
}