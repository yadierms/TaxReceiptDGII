import axios from "axios";

const API_BASE_URL = "https://localhost:7075/api"; // URL base de tu API

const ApiService = {
  async obtenerContribuyentes() {
    try {
      const response = await axios.get(`${API_BASE_URL}/contribuyente`);
      return response.data;
    } catch (error) {
      console.error("Error al obtener los contribuyentes:", error);
      return [];
    }
  },

  async obtenerComprobantes() {
    try {
      const response = await axios.get(`${API_BASE_URL}/comprobante/`);
      return response.data;
    } catch (error) {
      console.error("Error al obtener los comprobantes:", error);
      return [];
    }
  },

  async obtenerComprobantesPorRnc(rncCedula) {
    try {
      const response = await axios.get(
        `${API_BASE_URL}/comprobante/${rncCedula}`
      );
      return response.data;
    } catch (error) {
      console.error("Error al obtener los comprobantes:", error);
      return [];
    }
  },
};

export default ApiService;
