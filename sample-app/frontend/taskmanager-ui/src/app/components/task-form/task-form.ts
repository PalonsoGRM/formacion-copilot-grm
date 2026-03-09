import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TaskItem, TaskService } from '../../services/task';

@Component({
  selector: 'app-task-form',
  imports: [FormsModule],
  templateUrl: './task-form.html',
  styleUrl: './task-form.css',
})
// DEFECTO INTENCIONAL: sin validación de formulario en el cliente
export class TaskForm {
  @Output() taskCreated = new EventEmitter<TaskItem>();

  task: Partial<TaskItem> = {
    title: '',
    description: '',
    status: 'todo',
    projectId: 1,
  };

  constructor(private taskService: TaskService) {}

  onSubmit(): void {
    // DEFECTO: no valida que title no esté vacío antes de enviar
    this.taskService.createTask(this.task).subscribe(created => {
      this.taskCreated.emit(created);
      this.task = { title: '', description: '', status: 'todo', projectId: 1 };
    });
  }
}
