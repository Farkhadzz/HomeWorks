document.addEventListener('DOMContentLoaded', function () {
    const urlParams = new URLSearchParams(window.location.search);
    const taskTitle = urlParams.get('title');
    const taskDescription = urlParams.get('description');
    const taskPriority = urlParams.get('priority');
    const taskDate = urlParams.get('date');
  
    const titleElement = document.getElementById('task-title');
    titleElement.textContent = taskTitle;
  
    const descriptionElement = document.getElementById('task-description');
    descriptionElement.textContent = taskDescription;
  
    const priorityElement = document.getElementById('task-priority');
    priorityElement.textContent = taskPriority;
  
    const dateElement = document.getElementById('task-date');
    dateElement.textContent = taskDate;
  });
  