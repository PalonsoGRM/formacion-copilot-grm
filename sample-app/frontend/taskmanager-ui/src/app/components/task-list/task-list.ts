import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskItem, TaskService } from '../../services/task';

@Component({
  selector: 'app-task-list',
  imports: [CommonModule],
  templateUrl: './task-list.html',
  styleUrl: './task-list.css',
})
// DEFECTO INTENCIONAL: sin loading state, sin manejo de errores, sin unsubscribe
export class TaskList implements OnInit {
  tasks: TaskItem[] = [];

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    // DEFECTO: sin manejo de error si la API no responde
    this.taskService.getTasks().subscribe(tasks => {
      this.tasks = tasks;
    });
  }

  deleteTask(id: number): void {
    // DEFECTO: sin confirmación al usuario antes de borrar
    this.taskService.deleteTask(id).subscribe(() => {
      this.tasks = this.tasks.filter(t => t.id !== id);
    });
  }

  getStatusLabel(status: string): string {
    // DEFECTO: magic strings duplicados (los mismos que en el backend)
    if (status === 'todo') return 'Pendiente';
    if (status === 'in-progress') return 'En curso';
    if (status === 'done') return 'Hecho';
    return status;
  }
}
