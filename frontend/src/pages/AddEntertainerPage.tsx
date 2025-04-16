import React from "react";
import { useNavigate } from "react-router-dom";
import EntertainerForm from "../components/EntertainerForm";
import { addEntertainer } from "../api/EntertainmentAPI";
import BackButton from "../components/BackButton";

const today = new Date().toISOString().split("T")[0]; // "2025-04-16"

const AddEntertainerPage: React.FC = () => {
  const navigate = useNavigate();

  const handleSubmit = async (data: any) => {
    try {
      await addEntertainer(data);
      navigate("/entertainers");
    } catch (err) {
      alert("Failed to add entertainer.");
    }
  };

  return (
    <div className="container mt-4">
      <BackButton />
      <h2>Add Entertainer</h2>
      <EntertainerForm onSubmit={handleSubmit} initialData={{ dateEntered: today }} />
    </div>
  );
};

export default AddEntertainerPage;