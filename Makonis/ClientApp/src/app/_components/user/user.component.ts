import { Component, OnInit } from '@angular/core';
import { Response } from '../../_models/response.model';
import { User } from '../../_models/user.model';
import { UserService } from '../../_services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  user: User;
  constructor(private userService: UserService) {
    this.user = new User();
  }

  ngOnInit() {
  }
  saveDetails() {
    this.user.firstName = this.user.firstName ? this.user.firstName.trim() : '';
    this.user.lastName = this.user.lastName ? this.user.lastName.trim() : '';
    if (this.user.firstName && this.user.lastName)
      this.userService.saveUser(this.user).subscribe((response: Response) => {
        alert(response.message);
      },
        (response) => {
          if (response.error.status == 500)
            alert(response.error.title);
          else
            alert(response.error.message);
        });
  }
}
