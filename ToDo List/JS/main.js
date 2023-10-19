class Task {
  constructor(title, description, createdDate, isCompleted, priority) {
      this.id = this.generateUniqueId();
      this.title = title;
      this.description = description;
      this.createdDate = createdDate;
      this.isCompleted = isCompleted;
      this.priority = priority;
  }

  generateUniqueId() {
      return Date.now().toString();
  }
}

class TaskList {
  constructor() {
      this.tasks = [];
  }

  addTask(task) {
      this.tasks.push(task);
  }
}

const taskList = new TaskList();

const newTaskForm = document.getElementById('new-task-form');
const newTaskSubmit = document.getElementById('new-task-submit');
const taskListDiv = document.getElementById('tasks');

newTaskSubmit.addEventListener('click', function (e) {
  e.preventDefault();

  const newTaskTitle = document.getElementById('new-task-input').value;
  const newTaskDescription = document.getElementById('new-task-desc').value;
  const newTaskPrioritySelect = document.getElementById('new-task-priority');
  const newTaskPriority = newTaskPrioritySelect.value;

  if (newTaskTitle && newTaskDescription) {
      const currentDate = new Date();
      const formattedDate = currentDate.toLocaleString();
      const newTask = new Task(newTaskTitle, newTaskDescription, formattedDate, false, newTaskPriority);

      taskList.addTask(newTask);

      document.getElementById('new-task-input').value = '';
      document.getElementById('new-task-desc').value = '';

      // Обновляем интерфейс для отображения новой задачи
      displayTask(newTask);
  } else {
      alert('Пожалуйста, заполните все поля формы.');
  }
});

function displayTask(task) {
  const taskDiv = document.createElement('div');
  taskDiv.classList.add('task');

  const contentDiv = document.createElement('div');
  contentDiv.classList.add('content');

  const inputText = document.createElement('input');
  inputText.setAttribute('type', 'text');
  inputText.classList.add('text');
  inputText.value = task.title;
  inputText.readOnly = true;
  inputText.setAttribute('data-priority', task.priority);

  const actionsDiv = document.createElement('div');
  actionsDiv.classList.add('actions');

  const viewButton = document.createElement('button');
  viewButton.classList.add('view');
  viewButton.textContent = 'View';

  const editButton = document.createElement('button');
  editButton.classList.add('edit');
  editButton.textContent = 'Edit';

  const applyButton = document.createElement('button');
  applyButton.classList.add('apply');
  applyButton.textContent = 'Apply';
  applyButton.style.display = 'none';

  const deleteButton = document.createElement('button');
  deleteButton.classList.add('delete');
  deleteButton.textContent = 'Delete';

  deleteButton.addEventListener('click', function () {
    deleteTask(task);
    taskDiv.remove();
});

  // Обработчик события для кнопки Edit
  editButton.addEventListener('click', function () {
      inputText.readOnly = false;
      editButton.style.display = 'none';
      applyButton.style.display = 'block';
  });

  // Обработчик события для кнопки Apply
  applyButton.addEventListener('click', function () {
      inputText.readOnly = true;
      editButton.style.display = 'block';
      applyButton.style.display = 'none';

      task.title = inputText.value;
  });

  contentDiv.appendChild(inputText);
  actionsDiv.appendChild(viewButton);
  actionsDiv.appendChild(editButton);
  actionsDiv.appendChild(applyButton);
  actionsDiv.appendChild(deleteButton);

  taskDiv.appendChild(contentDiv);
  taskDiv.appendChild(actionsDiv);

  taskListDiv.appendChild(taskDiv);
}


function deleteTask(task) {
  const taskIndex = taskList.tasks.indexOf(task);
  if (taskIndex !== -1) {
      taskList.tasks.splice(taskIndex, 1);
  }
}

function sortTasksByPriority() {
  const taskContainer = document.getElementById('tasks');
  const taskList = Array.from(taskContainer.getElementsByClassName('task'));

  taskList.sort((a, b) => {
      const priorityA = a.querySelector('.text').getAttribute('data-priority');
      const priorityB = b.querySelector('.text').getAttribute('data-priority');

      if (priorityA < priorityB) {
          return -1;
      }
      if (priorityA > priorityB) {
          return 1;
      }
      return 0;
  });

  taskContainer.innerHTML = '';
  taskList.forEach(task => taskContainer.appendChild(task));
}