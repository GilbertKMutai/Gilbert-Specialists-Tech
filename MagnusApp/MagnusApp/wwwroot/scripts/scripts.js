let sections = document.querySelectorAll(".sub-container");
window.onscroll = () => {
    sections.forEach(sec => {
        let top = window.scrollY;
        let offset = sec.offsetTop - 150;
        let height = sec.offsetHeight;

        if (top >= offset && top < offset + height) {
            sec.classList.add("show-animate");
        }
        //if want to use repeating animation on scroll use this
        else {
            sec.classList.remove("show-animate");
        }
    })
}



gsap.registerPlugin(ScrollTrigger);
const ac = gsap.utils.toArray(".ac");

// these values work
const delay = 0;
const duration = 1;
const offset = 200;

// these values don't work if scrolled faster.
// const delay = 0.5;
// const duration = 0.5;
// const offset = 100;

ScrollTrigger.create({
    trigger: ".pp",
    start: "top top",
    endTrigger: ".container",
    end: "bottom top",
    pin: true,
    pinSpacing: false,
    markers: true
});

document.querySelectorAll(".animated-section").forEach((section, index) => {
    const heading = ac[index].querySelectorAll("h2, p, img");

    if (index !== 0) {
        gsap.set(ac[index].querySelectorAll("h2, p, img"), { yPercent: offset });
    }

    ScrollTrigger.create({
        trigger: section,
        start: "top top",
        end: "bottom top",
        markers: true,
        fastScrollEnd: true,
        preventOverlap: true,
        onEnter: () => {
            gsap.to(heading, { yPercent: 0, delay, duration });
        },
        onLeaveBack: () => {
            if (index !== 0) {
                gsap.to(heading, { yPercent: offset, duration });
            }
        },
        onEnterBack: () => {
            gsap.to(heading, { yPercent: 0, delay, duration });
        },
        onLeave: () => {
            if (index !== 3) {
                gsap.to(heading, { yPercent: -offset, duration });
            }
        }
    });
});