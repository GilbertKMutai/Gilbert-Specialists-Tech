//let sections = document.querySelectorAll(".sub-container");
//window.onscroll = () => {
//    sections.forEach(sec => {
//        let top = window.scrollY;
//        let offset = sec.offsetTop - 150;
//        let height = sec.offsetHeight;

//        if (top >= offset && top < offset + height) {
//            sec.classList.add("show-animate");
//        }
//        //if want to use repeating animation on scroll use this
//        else {
//            sec.classList.remove("show-animate");
//        }
//    })
//};



//window.showAnimation = () => {
//    DotNet.invokeMethodAsync("MagnusApp.Client", "AddAnimation");
//};



//const boxes = document.querySelectorAll(".sub-container")
//window.addEventListener("scroll", () => {
//    const innerHeightOfWindow = window.innerHeight;
//    boxes.forEach(box => {
//        const boxTop = box.getBoundingClientRect().top
//        if (boxTop < innerHeightOfWindow) {
//            DotNet.invokeMethodAsync('MagnusApp.Client', 'AddAnimation');
//        }
//        // else {
//        //     box.classList.remove("show-animate")
//        // }  
//    });
//});