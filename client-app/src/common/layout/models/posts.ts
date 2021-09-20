export interface PostedBy {
  firstName: string;
  userName: string;
  surName: string;
  profilePic: string;
}

export interface Posts {
  id: string;
  post: string;
  totalLikes: number;
  isSharedPost: boolean;
  totalComments: number;
  postedDate: Date;
  postedBy: PostedBy;
}
