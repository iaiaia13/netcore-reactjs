import React, { useState, FormEvent } from "react";
import { Segment, Form, Button } from "semantic-ui-react";
import { IActivity } from "../../../app/models/IActivity";
import {v4 as uuid} from "uuid";

interface IProps {
  setEditMode: (editMode: boolean) => void;
  activity: IActivity;
  createActivity: (activity: IActivity) => void;
  editActivity: (activity: IActivity) => void;
}

export const ActivityForm: React.FC<IProps> = ({
  setEditMode,
  activity: initializeFormState,
  createActivity,
  editActivity
}) => {
  const initializeForm = () => {
    if (initializeFormState) return initializeFormState;
    else {
      return {
        id: "",
        title: "",
        category: "",
        description: "",
        date: "",
        city: "",
        venue: "",
      };
    }
  };

  const [activity, setActivity] = useState<IActivity>(initializeForm);

  const hadleInputChange = (event: FormEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = event.currentTarget;
    setActivity({ ...activity, [name]: value });
  };

  const handleSubmit = () => {
      if(activity.id.length === 0){
        let newActivity = {
          ...activity,
          id: uuid()
        }

        createActivity(newActivity)
      }else{
        editActivity(activity);
      }
  };

  return (
    <Segment clearing>
      <Form onSubmit={handleSubmit}>
        <Form.Input
          name="title"
          onChange={hadleInputChange}
          placeholder="Title"
          value={activity.title}
        />
        <Form.TextArea
          name="description"
          onChange={hadleInputChange}
          row={2}
          placeholder="Description"
          value={activity.description}
        />
        <Form.Input 
          name="category"
          onChange={hadleInputChange} placeholder="Category" value={activity.category} />
        <Form.Input 
          name="date"
          onChange={hadleInputChange} type="datetime-local" placeholder="Date" value={activity.date} />
        <Form.Input 
          name="city"
          onChange={hadleInputChange} placeholder="City" value={activity.city} />
        <Form.Input  
          name="venue"
          onChange={hadleInputChange}
          placeholder="Venue" value={activity.venue} />
        <Button type="submit" content="Submit" positive floated="right" />
        <Button
          type="button"
          content="Cancel"
          floated="right"
          onClick={() => setEditMode(false)}
        />
      </Form>
    </Segment>
  );
};
