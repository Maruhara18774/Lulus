import axios from "axios";
const endpoint = 'https://localhost:44354/api';
export let token = "";
let config = {
    headers: {
      "Authorization": "Bearer "+ token
    }
  }
export function SetToken(value) {
    token = value;
}
export async function Get(url) {
    return await axios.get(endpoint+url,config);
}

export async function Post(url,data) {
    return await axios.post(endpoint+url,data,config);
}
