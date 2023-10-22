const task = getTaskParamsFromURL();

// Функция для извлечения параметров задачи из URL
function getTaskParamsFromURL() {
    const urlParams = new URLSearchParams(window.location.search);
    return {
        title: urlParams.get('title'),
        description: urlParams.get('description'),
        date: urlParams.get('date'),
        priority: urlParams.get('priority'),
    };
}

// Отображаем информацию о задаче на странице
document.getElementById('taskTitle').textContent = task.title;
document.getElementById('taskDescription').textContent = task.description;
document.getElementById('taskDate').textContent = task.date;
document.getElementById('taskPriority').textContent = task.priority;