// Класс для задачи
class Task {
  constructor(title, description, date, isCompleted, priority) {
    this.title = title;
    this.description = description;
    this.date = date;
    this.isCompleted = isCompleted;
    this.priority = priority;
  }
}

// Класс для списка задач
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

// Создаем экземпляр TaskList
const taskList = new TaskList();

// Обработчик события для кнопки "Add Task" (открытие модального окна)
const addTaskButton = document.getElementById('addTaskButton');
addTaskButton.addEventListener('click', function () {
  const taskModal = document.getElementById('taskModal');
  taskModal.style.display = 'block'; // Открываем модальное окно
});

// Обработчик события для кнопки "Cancel" (закрытие модального окна)
const closeModalButton = document.getElementById('closeModalButton');
closeModalButton.addEventListener('click', function () {
  const taskModal = document.getElementById('taskModal');
  taskModal.style.display = 'none'; // Закрываем модальное окно
});

// Обработчик события для кнопки "Add Task" в модальном окне
const addTaskModalButton = document.getElementById('addTaskModalButton');
addTaskModalButton.addEventListener('click', function () {
  const titleInput = document.getElementById('modal-task-title');
  const descriptionInput = document.getElementById('modal-task-description');
  const priorityInput = document.getElementById('modal-task-priority');

  const title = titleInput.value;
  const description = descriptionInput.value;
  const priority = priorityInput.value;

  if (title && description) {
    // Создайте новую задачу
    const currentDate = new Date();
    const formattedDate = currentDate.toLocaleString();
    const newTask = new Task(title, description, formattedDate, false, priority);

    // Добавьте задачу в массив и обновите интерфейс
    taskList.addTask(newTask);
    displayTask(newTask);

    // Закройте модальное окно
    const taskModal = document.getElementById('taskModal');
    taskModal.style.display = 'none';

    // Сбросьте значения полей в модальном окне
    titleInput.value = '';
    descriptionInput.value = '';
  }
});

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
  actionsDiv.appendChild(editButton);
  actionsDiv.appendChild(applyButton);
  actionsDiv.appendChild(deleteButton);

  taskDiv.appendChild(contentDiv);
  taskDiv.appendChild(actionsDiv);

  taskListDiv.appendChild(taskDiv);

  // Обработчик события для кнопки "Edit"
  editButton.addEventListener('click', function () {
    inputText.readOnly = false; // Разрешаем редактирование текста
    editButton.style.display = 'none'; // Скрываем кнопку Edit
    applyButton.style.display = 'block'; // Показываем кнопку Apply
  });

  // Обработчик события для кнопки "Apply"
  applyButton.addEventListener('click', function () {
    const updatedTitle = inputText.value;
    // Обновите задачу в массиве
    task.title = updatedTitle;
    inputText.readOnly = true; // Запрещаем редактирование текста
    applyButton.style.display = 'none'; // Скрываем кнопку Apply
    editButton.style.display = 'block'; // Показываем кнопку Edit
  });

  // Обработчик события для кнопки "Delete"
  deleteButton.addEventListener('click', function () {
    // Удаляем задачу из массива
    taskList.removeTask(task);

    // Удаляем HTML элемент задачи
    taskListDiv.removeChild(taskDiv);
  });
}
