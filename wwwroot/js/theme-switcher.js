document.addEventListener('DOMContentLoaded', () => {
    const themeToggleButton = document.getElementById('theme-toggle');
    const bodyElement = document.body;
    const themeIcon = themeToggleButton.querySelector('i');
    const navbarLinks = document.querySelectorAll('.navbar-nav .nav-link');
    const cards = document.querySelectorAll('.card'); // Select all cards
  
    // Load the saved theme from localStorage
    const savedTheme = localStorage.getItem('theme');
    if (savedTheme) {
        bodyElement.classList.toggle('dark-mode', savedTheme === 'dark');
        themeIcon.classList.toggle('bi-sun', savedTheme === 'dark');
        themeIcon.classList.toggle('bi-moon', savedTheme !== 'dark');

        navbarLinks.forEach((link) => {
            link.style.color = savedTheme === 'dark' ? '#fff' : '#000';
        });

        cards.forEach((card) => {
            card.style.backgroundColor = savedTheme === 'dark' ? '#333' : '#fff';
            card.style.color = savedTheme === 'dark' ? '#fff' : '#000';
            const icon = card.querySelector('i');
            icon.style.color = savedTheme === 'dark' ? '#fff' : '#000';
        });
    }

    // Toggle the theme on button click
    themeToggleButton.addEventListener('click', () => {
        const isDarkMode = bodyElement.classList.toggle('dark-mode');
        themeIcon.classList.toggle('bi-sun', isDarkMode);
        themeIcon.classList.toggle('bi-moon', !isDarkMode);
        
        navbarLinks.forEach((link) => {
            link.style.color = isDarkMode ? '#fff' : '#000';
        });

        cards.forEach((card) => {
            card.style.backgroundColor = isDarkMode ? '#333' : '#fff';
            card.style.color = isDarkMode ? '#fff' : '#000';
            const icon = card.querySelector('i');
            icon.style.color = isDarkMode ? '#fff' : '#000';
        });

        localStorage.setItem('theme', isDarkMode ? 'dark' : 'light');
    });
});