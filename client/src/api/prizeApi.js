import axiosInstance from './axiosInstance';

export const getAllPrizes = () => {
  return axiosInstance.get('/prizes');
};
