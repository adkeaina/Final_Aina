import { Entertainer } from "../types/Entertainer";
import { EntertainerDetails } from "../types/EntertainerDetails";

const apiBaseUrl = 'https://final-backend-aina-bjbkhyb6f5enfne7.westus3-01.azurewebsites.net/api/entertainers';

export async function fetchEntertainers(): Promise<Entertainer[]> {
  const response = await fetch(apiBaseUrl);
  if (!response.ok) {
    throw new Error('Failed to fetch entertainers');
  }
  return response.json();
}

export async function fetchEntertainer(entertainerId: string): Promise<EntertainerDetails> {
  const response = await fetch(`${apiBaseUrl}/${entertainerId}`);
  if (!response.ok) {
    throw new Error('Failed to fetch entertainer');
  }
  return response.json();
}

export async function addEntertainer(data: EntertainerDetails): Promise<void> {
    console.log(data);
  const response = await fetch(apiBaseUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("Failed to add entertainer");
  }
}

export async function updateEntertainer(entertainerId: string, data: Partial<EntertainerDetails>): Promise<void> {
  const response = await fetch(`${apiBaseUrl}/${entertainerId}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("Failed to update entertainer");
  }
}

export async function deleteEntertainer(entertainerId: string): Promise<void> {
  const response = await fetch(`${apiBaseUrl}/${entertainerId}`, {
    method: "DELETE",
  });
  if (!response.ok) {
    throw new Error("Failed to delete entertainer");
  }
}