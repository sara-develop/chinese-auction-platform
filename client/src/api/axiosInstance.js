import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'http://localhost:5065/api', // שימי לב לשינוי הפורט
  headers: {
    'Content-Type': 'application/json',
  },
});

axiosInstance.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export default axiosInstance;
