import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import EntertainerForm from "../components/EntertainerForm";
import { EntertainerDetails } from "../types/EntertainerDetails";
import { fetchEntertainer, updateEntertainer } from "../api/EntertainmentAPI";
import BackButton from "../components/BackButton";

const EditEntertainerPage: React.FC = () => {
  const { entertainerId } = useParams();
  const navigate = useNavigate();
  const [entertainer, setEntertainer] = useState<EntertainerDetails | null>(null);

  useEffect(() => {
    if (entertainerId) {
      fetchEntertainer(entertainerId).then(setEntertainer).catch(console.error);
    }
  }, [entertainerId]);

  const handleSubmit = async (updatedData: Partial<EntertainerDetails>) => {
    if (entertainerId) {
      try {
        await updateEntertainer(entertainerId, updatedData);
        navigate(`/entertainers/${entertainerId}`);
      } catch (err) {
        alert("Failed to update entertainer.");
      }
    }
  };

  return (
    <div className="container mt-4">
      <h2>Edit Entertainer</h2>
      <BackButton />
      {entertainer && (
        <EntertainerForm initialData={entertainer} onSubmit={handleSubmit} />
      )}
    </div>
  );
};

export default EditEntertainerPage;