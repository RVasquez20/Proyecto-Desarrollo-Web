//creating database structure
const db = new Dexie('Todo App')
db.version(2).stores({ todos: '++id,doctor,clinica, nombre,apellido, fecha,hora' })

const form = document.querySelector("#new-task-form");
const Doctor = document.getElementsByClassName('Doctor');
const Clinica = document.getElementsByClassName('Clinica');
const Nombre = document.getElementsByClassName('Nombre');
const Apellido = document.getElementsByClassName('Apellido');
const Fecha = document.getElementsByClassName('Fecha');
const Hora = document.getElementsByClassName('Hora');
const list_el = document.querySelector("#tasks");



//add todo
form.onsubmit = async (event) => {
	event.preventDefault();
	const Doctores = Doctor[0].options[Doctor[0].selectedIndex].text;
	const Clinicas = Clinica[0].options[Clinica[0].selectedIndex].text;
	const Nombres = Nombre[0].value;
	const Apellidos = Apellido[0].value;
	const Fechas = Fecha[0].value;
	const Horas = Hora[0].value;
	await db.todos.add({ Doctores,Clinicas,Nombres, Apellidos, Fechas,Horas })
	await getTodos()
	form.reset()
};

//display todo
const getTodos = async () => {
	const allTodos = await db.todos.reverse().toArray()
	list_el.innerHTML = allTodos.map(todo => `
	
	<tbody class="task">
	
      <tr>
	  <td>${todo.Doctores}</td>
	  <td>${todo.Clinicas}</td>
	  <td>${todo.Nombres}</td>
	  <td>${todo.Apellidos}</td>
	  <td>${todo.Fechas}</td>
	  <td>${todo.Horas}</td>
	  <td><button class="delete btn btn-danger" onclick="deleteTodo(event, ${todo.id})">Delete</button></td>
	  </tr>
	
	
	</tbody>
	`).join("")

}
window.onload = getTodos

//delete todo
const deleteTodo = async (event, id) => {
	await db.todos.delete(id)
	await getTodos()
}