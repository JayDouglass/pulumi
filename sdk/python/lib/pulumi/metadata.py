# Copyright 2016-2018, Pulumi Corporation.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

from typing import Dict, Optional

from . import runtime


def get_project() -> str:
    """
    Returns the current project name.
    """
    return runtime.get_project()


def get_stack() -> str:
    """
    Returns the current stack name.
    """
    return runtime.get_stack()


def get_stack_tag(name: str) -> Optional[str]:
    """
    Returns a stack tag's value or None.
    """
    return runtime.get_stack_tag(name)


def get_stack_tags() -> Dict[str, str]:
    """
    Returns a copy of all the stack tags.
    """
    return runtime.get_stack_tags()
