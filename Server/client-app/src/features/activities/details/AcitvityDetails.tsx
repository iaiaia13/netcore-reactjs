import React from "react";
import { Card, Image, Button } from "semantic-ui-react";
import { IActivity } from "../../../app/models/IActivity";

interface IProps {
  activity: IActivity;
  setEditMode: (editMode: boolean) => void;
  setSelectedActivity: (activity: IActivity | null) => void;
}

export const AcitvityDetails: React.FC<IProps> = ({
  activity,
  setEditMode,
  setSelectedActivity,
}) => {
  return (
    <Card fluid>
      <Image
        src={`/assets/categoryImages/${activity.category}.jpg`}
        wrapped
        ui={false}
      />
      <Card.Content>
        <Card.Header>{activity.title}</Card.Header>
        <Card.Meta>
          <span className="date">{activity.date}</span>
        </Card.Meta>
        <Card.Description>{activity.description}</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <Button.Group widths={2}>
          <Button
            onClick={() => setSelectedActivity(null)}
            basic
            color="blue"
            content="Cancel"
          />
          <Button
            onClick={() => setEditMode(true)}
            basic
            color="grey"
            content="Edit"
          />
        </Button.Group>
      </Card.Content>
    </Card>
  );
};
