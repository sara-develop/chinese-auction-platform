import axiosInstance from './axiosInstance';

export const createTicket = (prizeId, userId) => {
  return axiosInstance.post('/tickets', {
    prizeId,
    userId,
    isDraft: true,
  });
};
