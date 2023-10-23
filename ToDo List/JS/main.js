class Task {
  constructor(title, description, date, isCompleted, priority) {
    this.title = title;
    this.description = description;
    this.date = date;
    this.isCompleted = isCompleted;
    this.priority = priority;
  }
}

class TaskList {
  constructor() {
    this.tasks = [];
  }

  addTask(task) {
    this.tasks.push(task);
  }

  removeTask(task) {
    const index = this.tasks.indexOf(task);
    if (index !== -1) {
      this.tasks.splice(index, 1);
    }
  }
}

const taskList = new TaskList();

function saveTasksToLocalStorage() {
  localStorage.setItem('tasks', JSON.stringify(taskList.tasks));
}

// Обработчик Modal "AddTask"
const addTaskButton = document.getElementById('addTaskButton');
addTaskButton.addEventListener('click', function () {
  const taskModal = document.getElementById('taskModal');
  taskModal.style.display = 'block';
});

// Обработчик Cancel
const closeModalButton = document.getElementById('closeModalButton');
closeModalButton.addEventListener('click', function () {
  const taskModal = document.getElementById('taskModal');
  taskModal.style.display = 'none';
});

// Обработчик AddTask
const addTaskModalButton = document.getElementById('addTaskModalButton');
addTaskModalButton.addEventListener('click', function () {
  const titleInput = document.getElementById('modal-task-title');
  const descriptionInput = document.getElementById('modal-task-description');
  const priorityInput = document.getElementById('modal-task-priority');

  const title = titleInput.value;
  const description = descriptionInput.value;
  const priority = priorityInput.value;

  if (title && description) {
    const currentDate = new Date();
    const formattedDate = currentDate.toLocaleString();
    const newTask = new Task(title, description, formattedDate, false, priority);

    taskList.addTask(newTask);
    displayTask(newTask);

    const taskModal = document.getElementById('taskModal');
    taskModal.style.display = 'none';

    saveTasksToLocalStorage();

    titleInput.value = '';
    descriptionInput.value = '';
  }
});

// Функция для отображения задач
function displayTask(task) {
  const taskListDiv = document.getElementById('tasks');

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

  const doneButton = document.createElement('button');
  doneButton.classList.add('done');
  doneButton.textContent = 'Done';

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

  contentDiv.appendChild(inputText);
  actionsDiv.appendChild(viewButton);
  actionsDiv.appendChild(doneButton);
  actionsDiv.appendChild(editButton);
  actionsDiv.appendChild(applyButton);
  actionsDiv.appendChild(deleteButton);

  taskDiv.appendChild(contentDiv);
  taskDiv.appendChild(actionsDiv);

  taskListDiv.appendChild(taskDiv);

  // Обработчик Edit
  editButton.addEventListener('click', function () {
    inputText.readOnly = false;
    editButton.style.display = 'none';
    applyButton.style.display = 'block';
  });

  // Обработчик Apply
  applyButton.addEventListener('click', function () {
    const updatedTitle = inputText.value;
    task.title = updatedTitle;
    inputText.readOnly = true;
    applyButton.style.display = 'none';
    editButton.style.display = 'block';

    saveTasksToLocalStorage();
  });

  // Обработчик Done
  doneButton.addEventListener('click', function () {
    task.isCompleted = true;
    taskListDiv.removeChild(taskDiv);
    saveTasksToLocalStorage();
  });

  // Обработчик Delete
  deleteButton.addEventListener('click', function () {
    taskList.removeTask(task);
    taskListDiv.removeChild(taskDiv);
    saveTasksToLocalStorage();
  });

  viewButton.addEventListener('click', function () {
    const taskTitle = task.title;
    const taskDescription = task.description;
    const taskPriority = task.priority;
    const taskDate = task.date;

    const viewUrl = `view.html?title=${encodeURIComponent(taskTitle)}&description=${encodeURIComponent(taskDescription)}&priority=${encodeURIComponent(taskPriority)}&date=${encodeURIComponent(taskDate)}`;

    window.open(viewUrl, 'Task View', 'width=400,height=400');
  });
}

// Функция для обновления списка задач
function updateTaskList(filterType) {
  const taskListDiv = document.getElementById('tasks');
  taskListDiv.innerHTML = '';

  taskList.tasks.forEach(function (task) {
    if (filterType === 'all' || (filterType === 'completed' && task.isCompleted) || (filterType === 'uncompleted' && !task.isCompleted)) {
      displayTask(task);
    }
  });
}

// Обработчик для фильтрации задач
const filterSelect = document.getElementById('filterSelect');
filterSelect.addEventListener('change', function () {
  const selectedFilter = filterSelect.value;
  updateTaskList(selectedFilter);
});

// Восстанавливаю задачи из localStorage при загрузке страницы, чтобы задачи не удалились при обновке.
window.addEventListener('load', function () {
  const taskListDiv = document.getElementById('tasks');
  const savedTasksJSON = localStorage.getItem('tasks');

  if (savedTasksJSON) {
    const savedTasks = JSON.parse(savedTasksJSON);
    savedTasks.forEach(function (taskData) {
      const task = new Task(
        taskData.title,
        taskData.description,
        taskData.date,
        taskData.isCompleted,
        taskData.priority
      );
      taskList.addTask(task);
    });
  }

  updateTaskList('all');
});
