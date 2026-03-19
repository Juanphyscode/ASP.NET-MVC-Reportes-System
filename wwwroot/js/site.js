document.addEventListener("DOMContentLoaded", function () {

    const toggler = document.querySelector('.navbar-toggler');
    const navbarMenu = document.querySelector('.navbar-collapse');

    if (toggler && navbarMenu) {
        toggler.addEventListener('click', function () {
            navbarMenu.classList.toggle('show');
            toggler.classList.toggle('active');
        });
    }

    const inputs = document.querySelectorAll('.login-card input');
    inputs.forEach(input => {
        input.addEventListener('focus', () => {
            input.style.borderColor = '#0066cc';
            input.style.boxShadow = '0 0 8px rgba(0,102,204,0.3)';
        });
        input.addEventListener('blur', () => {
            input.style.borderColor = '#ccc';
            input.style.boxShadow = 'none';
        });
    });

    const buttons = document.querySelectorAll('.login-card button');
    buttons.forEach(btn => {
        btn.addEventListener('mouseenter', () => {
            btn.style.transform = 'translateY(-2px)';
            btn.style.boxShadow = '0 6px 12px rgba(0,0,0,0.15)';
        });
        btn.addEventListener('mouseleave', () => {
            btn.style.transform = 'translateY(0)';
            btn.style.boxShadow = 'none';
        });
    });

    const footer = document.querySelector('.footer');
    const adjustFooter = () => {
        const bodyHeight = document.body.offsetHeight;
        const windowHeight = window.innerHeight;
        if (bodyHeight < windowHeight) {
            footer.style.position = 'absolute';
            footer.style.bottom = '0';
        } else {
            footer.style.position = 'relative';
        }
    };
    window.addEventListener('resize', adjustFooter);
    adjustFooter();

});