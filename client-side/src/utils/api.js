import axios from "axios";

const API_URL = "https://localhost:7173/api";

const axiosClient = axios.create({
  baseURL: API_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

export async function getApplications(pageNumber, pageSize) {
  return await axiosClient
    .get(`/applications?PageNumber=${pageNumber}&PageSize=${pageSize}`)
    .then((response) => response.data);
}

export async function createApplication(body) {
  return await axiosClient.post(`/applications`, body).then(response => response.data);
}

export async function getProducts(pageNumber, pageSize) {
  return await axiosClient
  .get(`/products?PageNumber=${pageNumber}&PageSize=${pageSize}`)
  .then((response) => response.data);
}

export async function getCategories(pageNumber, pageSize) {
  return await axiosClient
  .get(`/categories?PageNumber=${pageNumber}&PageSize=${pageSize}`)
  .then((response) => response.data);
}
