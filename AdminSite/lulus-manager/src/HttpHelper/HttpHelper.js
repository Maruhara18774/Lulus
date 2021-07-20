const endpoint = 'https://localhost:44354/api';
import axios from "axios";

export async function Get(url) {
    return await axios.get(endpoint+url);
}

export async function Post(url,data) {
    return await axios.post(endpoint+url,data);
}
