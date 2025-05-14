import axios from 'axios';

// Use the correct port where your .NET API is running
const API_URL = 'http://localhost:5035/api';

export const api = {
  getAllTodos: async () => {
    const response = await axios.get(`${API_URL}/todos`);
    return response.data;
  },
  
  getTodoById: async (id) => {
    const response = await axios.get(`${API_URL}/todos/${id}`);
    return response.data;
  },
  
  createTodo: async (todo) => {
    const response = await axios.post(`${API_URL}/todos`, todo);
    return response.data;
  },
  
  updateTodo: async (id, todo) => {
    await axios.put(`${API_URL}/todos/${id}`, todo);
  },
  
  deleteTodo: async (id) => {
    await axios.delete(`${API_URL}/todos/${id}`);
  }
};