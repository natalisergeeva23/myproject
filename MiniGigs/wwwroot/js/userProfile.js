// userProfile.js
document.addEventListener("DOMContentLoaded", function () {
    var userId = localStorage.getItem('userId');

    if (userId) { // Убедитесь, что userId существует
        fetch(`http://172.20.10.2:5089/api/Users/${userId}`, {
            method: 'GET',
            headers: {
                'Accept': 'text/plain',
                'Authorization': 'Bearer ' + localStorage.getItem('userToken')
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(userData => {
                // Обновляем информацию на странице
                var usernameElements = document.querySelectorAll('.username'); // Используйте класс .username для всех элементов, где нужно отобразить имя пользователя
                usernameElements.forEach(function (element) {
                    element.textContent = userData.name;
                });
            })
            .catch(error => console.error('Failed to fetch user data:', error));
    }
});
