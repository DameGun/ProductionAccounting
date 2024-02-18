import axios from "axios";

const API_URL = "https://localhost:7173/api";

const axiosClient = axios.create({
  baseURL: API_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

// ProductionApplication apiCalls

export async function setActiveApplication(id) {
  return await axiosClient
    .post(`/applications/setApplicationActive/${id}`)
    .then((response) => response.data);
}

export async function createProductionUnit(body) {
  return await axiosClient
    .post(`/productUnits`, body)
    .then((response) => response.data);
}

export async function getApplications(pageNumber, pageSize) {
  return await axiosClient
    .get(`/applications?PageNumber=${pageNumber}&PageSize=${pageSize}`)
    .then((response) => response.data);
}

export async function getApplicationById(id) {
  return await axiosClient
    .get(`/applications/${id}`)
    .then((response) => response.data);
}

export async function createApplication(body) {
  return await axiosClient
    .post(`/applications`, body)
    .then((response) => response.data);
}

export async function updateApplication(body) {
  return await axiosClient
    .put(`/applications/${body.id}`, body)
    .then((response) => response.data);
}

export async function deleteApplication(id) {
  return await axiosClient
    .delete(`/applications/${id}`)
    .then((response) => response.data);
}

// Products apiCalls

export async function getProducts(pageNumber, pageSize) {
  return await axiosClient
    .get(`/products?PageNumber=${pageNumber}&PageSize=${pageSize}`)
    .then((response) => response.data);
}

export async function createProduct(body) {
  return await axiosClient
    .post(`/products`, body)
    .then((response) => response.data);
}

export async function updateProduct(body) {
  return await axiosClient
    .put(`/products/${body.id}`, body)
    .then((response) => response.data);
}

export async function deleteProduct(id) {
  return await axiosClient
    .delete(`/products/${id}`)
    .then((response) => response.data);
}

// Categories apiCalls

export async function getCategories(pageNumber, pageSize) {
  return await axiosClient
    .get(`/categories?PageNumber=${pageNumber}&PageSize=${pageSize}`)
    .then((response) => response.data);
}

export async function createCategory(body) {
  return await axiosClient
    .post(`/categories`, body)
    .then((response) => response.data);
}

export async function updateCategory(body) {
  return await axiosClient
    .put(`/categories/${body.id}`, body)
    .then((response) => response.data);
}

export async function deleteCategory(id) {
  return await axiosClient
    .delete(`/categories/${id}`)
    .then((response) => response.data);
}
