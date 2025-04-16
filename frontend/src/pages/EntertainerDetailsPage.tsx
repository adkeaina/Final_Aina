import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { EntertainerDetails } from "../types/EntertainerDetails";
import { deleteEntertainer, fetchEntertainer } from "../api/EntertainmentAPI";
import BackButton from "../components/BackButton";

const EntertainerDetailsPage: React.FC = () => {
  const { entertainerId } = useParams<{ entertainerId: string }>();
  const navigate = useNavigate();
  const [entertainer, setEntertainer] = useState<EntertainerDetails | null>(null);

  const labelMap: Record<string, string> = {
    entertainerId: "ID",
    entStageName: "Stage Name",
    entSsn: "SSN",
    entStreetAddress: "Street Address",
    entCity: "City",
    entState: "State",
    entZipCode: "Zip Code",
    entPhoneNumber: "Phone Number",
    entWebPage: "Web Page",
    entEmailAddress: "Email Address",
    dateEntered: "Date Entered",
  };

  useEffect(() => {
    const loadEntertainer = async () => {
      try {
        const data = await fetchEntertainer(entertainerId!);
        setEntertainer(data);
      } catch (err) {
        console.error(err);
      }
    };

    loadEntertainer();
  }, [entertainerId]);

  const handleEdit = () => {
    navigate(`/entertainers/${entertainerId}/edit`);
  };

  const handleDelete = async () => {
    const confirm = window.confirm("Are you sure you want to delete this entertainer?");
    if (!confirm) return;

    try {
      await deleteEntertainer(entertainerId!);
      navigate("/entertainers");
    } catch (err) {
      console.error(err);
    }
  };

  if (!entertainer) return <p>Loading...</p>;

  return (
    <div className="container mt-4">
      <BackButton navigation={() => navigate('/entertainers')}/>
      <h2 className="mb-4">Entertainer Details</h2>
      <table className="table">
        <tbody>
          {Object.entries(entertainer).map(([key, value]) => (
            <tr key={key}>
            <th>{labelMap[key] ?? key}</th>
            <td>{value ?? "N/A"}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <div className="d-flex justify-content-between mt-4">
        <button className="btn btn-primary" onClick={handleEdit}>
          Edit
        </button>
        <button className="btn btn-danger" onClick={handleDelete}>
          Delete
        </button>
      </div>
    </div>
  );
};

export default EntertainerDetailsPage;